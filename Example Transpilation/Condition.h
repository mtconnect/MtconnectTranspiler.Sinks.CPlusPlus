#include <unordered_map>
#include <vector>
#include <string>

namespace  {
    class Condition {
    public:
        inline static std::unordered_map<std::string, std::vector<std::string>> ConditionConstraints = {
		{ "Actuator", {  } }, 
		{ "Communications", {  } }, 
		{ "DataRange", {  } }, 
		{ "LogicProgram", {  } }, 
		{ "MotionProgram", {  } }, 
		{ "System", {  } }
        };
    };

    // No need to define Constraints outside the class in C++17 or later
}
