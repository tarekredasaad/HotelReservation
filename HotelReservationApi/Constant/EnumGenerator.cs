using System.Reflection.Emit;
using System.Reflection;
using HotelReservationApi.Data;

namespace HotelReservationApi.Constant
{
    public static class EnumGenerator
    {
        public static Type CreateFacilityEnum()
        {
            // Define a new assembly and module to hold the enum
            var assemblyName = new AssemblyName("DynamicEnums");
            var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");

            // Define the enum
            var enumBuilder = moduleBuilder.DefineEnum("FacilityEnum", TypeAttributes.Public, typeof(int));

            // Use your DbContext to get the facilities
            using (var context = new Context())
            {
                var facilities = context.Facilities.ToList();

                // Define literals in the enum for each facility
                foreach (var facility in facilities)
                {
                    enumBuilder.DefineLiteral(facility.name.Replace(" ", "_"), facility.Id);
                }
            }

            // Create and return the enum type
            return enumBuilder.CreateTypeInfo().AsType();
        }
    }
}
