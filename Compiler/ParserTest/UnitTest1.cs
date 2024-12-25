using System.Reflection;
using WinFormsApp1;
using Xunit;

namespace ParserTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("صحيح  س = 2 ;\r\n\r\nمتغير س [ 33 ] ;", "Parser Output:\r\nParsing successful! Rules called:\r\nDeclaration\r\nDeclaration\r\n")]
        [InlineData("صحيح دالة (صحيح س , صحيح ص) \r\n{\r\n\r\n}", "Parser Output:\r\nParsing successful! Rules called:\r\nDeclaration\r\n")]
        [InlineData("من ( صحيح ش في   ( س الي ص  + ض  )  ) \r\n{\r\n\r\n}", "Parser Output:\r\nParsing successful! Rules called:\r\nLoop\r\n")]
        [InlineData("اذا (س <= ص  + ض) \r\n{\r\n\r\n}\r\n\r\nاخر\r\n{\r\n\r\n\r\n}", "Parser Output:\r\nParsing successful! Rules called:\r\nConditionStmt\r\n")]
        [InlineData("س = ص  (  ض ) ;\r\n\r\n س = ص ;", "Parser Output:\r\nParsing successful! Rules called:\r\nAssign\r\nAssign\r\n")]
        [InlineData("اطبع (س) ;\r\n\r\nاطبع (١٢) ;", "Parser Output:\r\nParsing successful! Rules called:\r\nPrint\r\nPrint\r\n")]
        [InlineData("متغير x = 10; \r\nاذا (x > 5) { \r\nx = x + 1; \r\n} ", "Parser Output:\r\nParsing successful! Rules called:\r\nDeclaration\r\nConditionStmt\r\nAssign\r\n")]
        [InlineData("متغير x = 10; \r\nطالما(x < 10) { \r\nx = x + 2; \r\n}", "Parser Output:\r\nParsing successful! Rules called:\r\nDeclaration\r\nLoop\r\nAssign\r\n")]
        [InlineData("// تعريف الدالة\r\n\r\nصحيح دالة (صحيح س) \r\n{\r\n  // لوب من 2 الي قيمة س\r\n\r\n  من ( صحيح ص في ( ٢ الي س / 2 ) ) \r\n  {\r\n      اذا ( س % ص == 0 ) \r\n      {\r\n        // ارجع صفر لو الرقم غير اولي\r\n\r\n          ارجع 0 ;\r\n      }\r\n\r\n      // ارجع واحد لو الرقم اولي\r\n\r\n      ارجع 1 ;\r\n  }\r\n}  \r\n\r\nصحيح س = 13 ;\r\n\r\nصحيح اولي  = دالة ( س ) ;\r\n\r\nاولي  = دالة ( ١٢  ) ;\r\n\r\n// نطبع القيمة الراجعة من الدالة\r\n\r\nاطبع (  اولي) ;\r\n"
            , "Parser Output:\r\nParsing successful! Rules called:\r\nDeclaration\r\nLoop\r\nConditionStmt\r\nFunc_Return\r\nFunc_Return\r\nDeclaration\r\nDeclaration\r\nAssign\r\nPrint\r\n")]
        [InlineData("// تعريف الدالة\r\n\r\nصحيح دالة (صحيح س , صحيح ع) \r\n{\r\n   صحيح ص = 1 ;\r\n   صحيح ناتج = 0 ;  \r\n  // لوب من 1 الي قيمة ع\r\n  طالما ( ص <=  س) \r\n  {\r\n      اذا ( ص % ع == 0 ) \r\n      {\r\n              ناتج = ناتج + ص ;\r\n      }\r\n      ص = ص + 1 ;\r\n  }\r\n      // ارجع الناتج\r\n\r\n      ارجع ناتج  ;\r\n}  \r\n\r\nصحيح س = 13 ;\r\n\r\nصحيح مجموع = دالة ( س  , 3) ;\r\n\r\n// نطبع القيمة الراجعة من الدالة\r\n\r\nاطبع (  مجموع ) ;"
            , "Parser Output:\r\nParsing successful! Rules called:\r\nDeclaration\r\nDeclaration\r\nDeclaration\r\nLoop\r\nConditionStmt\r\nAssign\r\nAssign\r\nFunc_Return\r\nDeclaration\r\nDeclaration\r\nPrint\r\n")]
        public void Test1(string input,string exp)
        {
            var form = new Form1();
            var txt = form.Txt1;
            txt.Text = input;

            MethodInfo button2_Click = typeof(Form1).GetMethod("button2_Click",
            System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance);

            button2_Click.Invoke(form, new object[] { null, EventArgs.Empty });
            var res = form.Txt2.Text;
            Assert.Equal(exp, res);
        }
    }
}