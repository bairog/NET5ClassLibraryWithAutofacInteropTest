#include "NET5ClassLibraryInterop.h"

namespace NET5ClassLibraryInterop
{
	std::int32_t NET5nterop::GetInt()
	{
		auto ret = NET5ClassLibraryInterface::Class1::GetInt();
		return static_cast<std::int32_t>(ret);
	}

	double NET5nterop::GetDouble()
	{
		auto ret = NET5ClassLibraryInterface::Class1::GetDouble();
		return static_cast<double>(ret);
	}
}