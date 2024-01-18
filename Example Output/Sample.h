#include <unordered_map>
#include <vector>
#include <string>

namespace  {
    class Sample {
    public:
        inline static std::unordered_map<std::string, std::vector<std::string>> SampleConstraints = {
		{ "Acceleration", {  } }, 
		{ "AccumulatedTime", {  } }, 
		{ "Amperage", {  } }, 
		{ "Angle", {  } }, 
		{ "AngularAcceleration", {  } }, 
		{ "AngularVelocity", {  } }, 
		{ "AxisFeedrate", {  } }, 
		{ "CapacityFluid", {  } }, 
		{ "CapacitySpatial", {  } }, 
		{ "Concentration", {  } }, 
		{ "Conductivity", {  } }, 
		{ "CuttingSpeed", {  } }, 
		{ "Density", {  } }, 
		{ "DepositionAccelerationVolumetric", {  } }, 
		{ "DepositionDensity", {  } }, 
		{ "DepositionMass", {  } }, 
		{ "DepositionRateVolumetric", {  } }, 
		{ "DepositionVolume", {  } }, 
		{ "Displacement", {  } }, 
		{ "ElectricalEnergy", {  } }, 
		{ "EquipmentTimer", {  } }, 
		{ "FillLevel", {  } }, 
		{ "Flow", {  } }, 
		{ "Frequency", {  } }, 
		{ "GlobalPosition", {  } }, 
		{ "Length", {  } }, 
		{ "Level", {  } }, 
		{ "LinearForce", {  } }, 
		{ "Load", {  } }, 
		{ "Mass", {  } }, 
		{ "PathFeedrate", {  } }, 
		{ "PathFeedratePerRevolution", {  } }, 
		{ "PathPosition", {  } }, 
		{ "PH", {  } }, 
		{ "Position", {  } }, 
		{ "PowerFactor", {  } }, 
		{ "Pressure", {  } }, 
		{ "ProcessTimer", {  } }, 
		{ "Resistance", {  } }, 
		{ "RotaryVelocity", {  } }, 
		{ "SoundLevel", {  } }, 
		{ "SpindleSpeed", {  } }, 
		{ "Strain", {  } }, 
		{ "Temperature", {  } }, 
		{ "Tension", {  } }, 
		{ "Tilt", {  } }, 
		{ "Torque", {  } }, 
		{ "Velocity", {  } }, 
		{ "Viscosity", {  } }, 
		{ "Voltage", {  } }, 
		{ "VoltAmpere", {  } }, 
		{ "VoltAmpereReactive", {  } }, 
		{ "VolumeFluid", {  } }, 
		{ "VolumeSpatial", {  } }, 
		{ "Wattage", {  } }, 
		{ "AmperageDC", {  } }, 
		{ "AmperageAC", {  } }, 
		{ "VoltageAC", {  } }, 
		{ "VoltageDC", {  } }, 
		{ "XDimension", {  } }, 
		{ "YDimension", {  } }, 
		{ "ZDimension", {  } }, 
		{ "Diameter", {  } }, 
		{ "Orientation", {  } }, 
		{ "HumidityRelative", {  } }, 
		{ "HumidityAbsolute", {  } }, 
		{ "HumiditySpecific", {  } }, 
		{ "PressurizationRate", {  } }, 
		{ "Deceleration", {  } }, 
		{ "AssetUpdateRate", {  } }, 
		{ "AngularDeceleration", {  } }, 
		{ "ObservationUpdateRate", {  } }, 
		{ "PressureAbsolute", {  } }, 
		{ "Openness", {  } }, 
		{ "DewPoint", {  } }, 
		{ "GravitationalForce", {  } }, 
		{ "GravitationalAcceleration", {  } }, 
		{ "BatteryCapacity", {  } }, 
		{ "DischargeRate", {  } }, 
		{ "ChargeRate", {  } }, 
		{ "BatteryCharge", {  } }, 
		{ "SettlingError", {  } }, 
		{ "SettlingErrorLinear", {  } }, 
		{ "SettlingErrorAngular", {  } }, 
		{ "FollowingError", {  } }, 
		{ "FollowingErrorAngular", {  } }, 
		{ "FollowingErrorLinear", {  } }, 
		{ "DisplacementLinear", {  } }, 
		{ "DisplacementAngular", {  } }, 
		{ "PositionCartesian", {  } }
        };
    };

    // No need to define Constraints outside the class in C++17 or later
}
