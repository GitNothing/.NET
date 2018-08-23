using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Reflection;

namespace IV
{
    class CodeDomExample
    {
        public CodeDomExample()
        {
            var provider = CodeDomProvider.CreateProvider("CSharp");
            var compileUnit = new CodeCompileUnit();

            var namespacing = new CodeNamespace("nameSpaceName");
            compileUnit.Namespaces.Add(namespacing);

            namespacing.Imports.Add(new CodeNamespaceImport("System"));

            var cls = new CodeTypeDeclaration("myClass");
            cls.TypeAttributes = TypeAttributes.Public;
            namespacing.Types.Add(cls);

            var member = new CodeMemberField();
            member.Name = "myMemberName";
            member.Type = new CodeTypeReference(typeof(int));
            member.Attributes = MemberAttributes.Public;

            var prop = new CodeMemberProperty();
            prop.Name = "abc";
            prop.HasGet = true;
            prop.HasSet = true;

            //creates a statement "return this.x;"
            var returnerGet = new CodeMethodReturnStatement(
                new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "x"));

            //create a statement "this.x = Value;"
            var assignerSet = new CodeAssignStatement(
                new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "x"),
                new CodePropertySetValueReferenceExpression());

            prop.GetStatements.Add(returnerGet);
            prop.SetStatements.Add(assignerSet);



            cls.Members.Add(member);
            cls.Members.Add(prop);
            cls.Members.Add(createMethod());

            var fileName = @"C:\Users\xxxx\Desktop\test." + provider.FileExtension;
            using (var s = new StreamWriter(fileName))
            {
                CodeGeneratorOptions options = new CodeGeneratorOptions();
                options.BlankLinesBetweenMembers = false;
                options.BracingStyle = "C";
                provider.GenerateCodeFromCompileUnit(compileUnit, s, new CodeGeneratorOptions());
            }

            var output = File.ReadAllText(fileName);
            Console.WriteLine(output);
        }

        CodeMemberMethod createMethod()
        {
            var divideMethod = new CodeMemberMethod();
            divideMethod.Name = "Divide";
            divideMethod.ReturnType = new CodeTypeReference(typeof(double));
            divideMethod.Attributes = MemberAttributes.Public | MemberAttributes.Final;

            var ifCondition = new CodeConditionStatement();
            ifCondition.Condition = new CodeBinaryOperatorExpression(new CodePrimitiveExpression(123), CodeBinaryOperatorType.GreaterThan, new CodePrimitiveExpression(1));

            ifCondition.TrueStatements.Add(new CodeMethodReturnStatement(new CodePrimitiveExpression(true)));

            ifCondition.FalseStatements.Add(new CodeMethodReturnStatement(new CodePrimitiveExpression(false)));

            divideMethod.Statements.Add(ifCondition);

            return divideMethod;
        }
    }
}

/*
OUTPUT:
namespace nameSpaceName {
    using System;


    public class myClass {

        public int myMemberName;

        private void abc {
            get {
                return this.x;
            }
            set {
                this.x = Value;
            }
        }

        public double Divide() {
            if ((123 > 1)) {
                return true;
            }
            else {
                return false;
            }
        }
    }
}

*/
