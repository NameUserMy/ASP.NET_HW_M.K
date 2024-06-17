namespace HW_2_MiddleWare
{
    public static class OneHundredToThousandExtensions
    {
        public static IApplicationBuilder Test(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<OneHundredToThousandMiddleWare>();
        }
    }
}
