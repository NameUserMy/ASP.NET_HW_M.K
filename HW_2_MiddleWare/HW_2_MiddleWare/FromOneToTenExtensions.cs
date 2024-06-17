namespace HW_2_MiddleWare
{
    public static class FromOneToTenExtensions
    {
        public static IApplicationBuilder UseFromOneToTen(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FromOneToTenMiddleWare>();
        }
    }
}
