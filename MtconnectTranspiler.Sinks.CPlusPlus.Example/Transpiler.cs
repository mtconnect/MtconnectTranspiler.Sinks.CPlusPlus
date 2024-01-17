using Microsoft.Extensions.Logging;
using MtconnectTranspiler.Contracts;
using MtconnectTranspiler.Sinks.CPlusPlus.Example.Models;
using MtconnectTranspiler.Sinks.CPlusPlus.Models;
using MtconnectTranspiler.Xmi;
using MtconnectTranspiler.Xmi.UML;
using Scriban.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MtconnectTranspiler.Sinks.CPlusPlus.Example
{

    public class CategoryFunctions : ScriptObject
    {
        public static bool CategoryContainsType(ObservationEnum @enum, EnumItem item) => @enum.SubTypes.ContainsKey(item.Name);
        public static bool CategoryContainsValue(ObservationEnum @enum, EnumItem item) => @enum.ValueTypes.ContainsKey(item.Name);
        public static bool EnumHasValues(ObservationEnum @enum) => @enum.ValueTypes.Any();
    }
    internal class Transpiler : CPlusPlusTranspiler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectPath"></param>
        public Transpiler(string projectPath, ILogger<ITranspilerSink>? logger = default) : base(projectPath, logger) { }

        public override void Transpile(XmiDocument model, CancellationToken cancellationToken = default)
        {
            _logger?.LogInformation("Received MTConnectModel, beginning transpilation");

            Model.SetValue("model", model, true);

            base.TemplateContext.PushGlobal(new CategoryFunctions());

            const string ObservationConstraintNamespace = "Example.Enums.DataItemValues";

            // Process DataItem Types/Sub-Types
            string[] categories = new string[] { "Sample", "Event", "Condition" };

            var categoryConstraints = new List<CategoryConstraints>();

            foreach (var category in categories)
            {
                var categoryConstraint = new CategoryConstraints() { Category = category };


                // Get the UmlPackage for the category (ie. Samples, Events, Conditions).
                var typesPackage = MTConnectHelper.JumpToPackage(
                    model!,
                    MTConnectHelper.PackageNavigationTree.ObservationInformationModel.ObservationTypes
                    )?
                    .Packages
                    .FirstOrDefault(o => o.Name == $"{category} Types");
                if (typesPackage == null)
                {
                    _logger?.LogTrace("Couldn't find {Category} Types", category);
                    continue;
                }

                // Get all DataItem Type and SubType references
                var allTypes = typesPackage
                    .Classes;
                // Filter to get just the Type references
                var types = allTypes
                    ?.Where(o => !o!.Name!.Contains('.'));
                if (types == null)
                {
                    _logger?.LogTrace("Couldn't find type classes for {Category} Types", category);
                    continue;
                }
                
                // Filter and group each SubType by the relevant Type reference
                var subTypes = allTypes
                    ?.Where(o => o!.Name!.Contains('.'))
                    ?.GroupBy(o => o!.Name![..o.Name!.IndexOf(".")], o => o)
                    ?.Where(o => o.Any())
                    ?.ToDictionary(o => o.Key, o => o?.ToList());

                foreach (var type in types)
                {
                    // Add type to CATEGORY enum
                    categoryConstraint.Constraints.Add(type.Name, new List<string>());

                    // Find value
                    var typeResult = type!.Properties?.FirstOrDefault(o => o.Name == "result");
                    if (typeResult != null)
                    {
                        var typeValuesSysEnum = MTConnectHelper.JumpToPackage(model!, MTConnectHelper.PackageNavigationTree.Profile.DataTypes)?
                            .Enumerations
                            .GetById(typeResult.PropertyType);
                        if (typeValuesSysEnum != null && typeValuesSysEnum is UmlEnumeration)
                        {
                            categoryConstraint.Constraints[type.Name] = typeValuesSysEnum.Items.Select(o => o.Name).ToList();
                        }
                    }

                    //// Add subType as enum
                    //if (subTypes != null && subTypes.ContainsKey(type.Name!))
                    //{
                    //    // Register type as having a subType in the CATEGORY enum
                    //    if (!categoryEnum.SubTypes.ContainsKey(type.Name!)) categoryEnum.SubTypes.Add(CppHelperMethods.ToUpperSnakeCode(type.Name), $"{type.Name}SubTypes");

                    //    var subTypeEnum = new ObservationEnum(model!, type, $"{type.Name}SubTypes") { Namespace = DataItemNamespace };

                    //    var typeSubTypes = subTypes[type.Name!];
                    //    subTypeEnum.AddRange(model, typeSubTypes);

                    //    // Cleanup Enum names
                    //    foreach (var item in subTypeEnum.Items)
                    //    {
                    //        if (!item.Name.Contains('.')) continue;
                    //        item.Name = CppHelperMethods.ToUpperSnakeCode(item.Name[(item.Name.IndexOf(".") + 1)..]);
                    //    }

                    //    // Register the DataItem SubType Enum
                    //    dataItemTypeEnums.Add(subTypeEnum);
                    //}

                }

                //// Cleanup Enum names
                //foreach (var item in categoryEnum.Items)
                //{
                //    item.Name = CppHelperMethods.ToUpperSnakeCode(item.Name);
                //}

                //// Register the DataItem Category Enum (ie. Samples, Events, Conditions)
                //dataItemTypeEnums.Add(categoryEnum);
                categoryConstraints.Add(categoryConstraint);
            }

            //_logger?.LogInformation("Processing {Count} DataItem types/subTypes", dataItemTypeEnums.Count);

            // Process the template into enum files
            //ProcessTemplate(dataItemTypeEnums, Path.Combine(ProjectPath, "Enums", "Devices", "DataItemTypes"), true);
            ProcessTemplate(categoryConstraints, Path.Combine(ProjectPath, "Enums"), true);
        }
    }
}
