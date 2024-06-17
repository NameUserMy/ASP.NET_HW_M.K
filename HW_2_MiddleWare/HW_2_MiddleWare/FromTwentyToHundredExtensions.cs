namespace HW_2_MiddleWare
{
    public static class FromTwentyToHundredExtensions
    {
        public static IApplicationBuilder UseFromTwentyToHundred(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FromTwentyToHundredMiddleware>();
        }
    }
}
