﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Parser
    {
        private List<Token> tokens;
        private Token currentToken;
        private int index;
        private List<string> errors;
        private List<string> rulesCalled;

        public Parser(List<Token> tokens)
        {
            this.tokens = tokens;
            this.currentToken = null;
            this.index = 0;
            this.errors = new List<string>();
            this.rulesCalled = new List<string>();
        }

        private void TrackFunction(Action function, string functionName)
        {
            rulesCalled.Add(functionName);
            function.Invoke();
        }

        private void Match(string tokenType)
        {
            if (currentToken != null && currentToken.IsToken(tokenType))
            {
                Consume();
            }
            else
            {
                Error(currentToken, tokenType);
            }
        }

        private void Consume()
        {
            index++;
            if (index < tokens.Count)
            {
                currentToken = tokens[index];
            }
            else
            {
                currentToken = new Token { Type = "EOF", Value = "" };
            }
        }

        private void Error(Token foundToken = null, string expectedType = null)
        {
            if (foundToken != null && expectedType != null)
            {
                errors.Add($"Error: Expected {expectedType} but found {foundToken}");
            }
            else
            {
                errors.Add("Error: Invalid syntax");
            }
        }

        public (List<string> Errors, List<string> RulesCalled) Parse()
        {
            if (tokens.Count == 0)
            {
                errors.Add("Error: No tokens to parse");
                return (errors, rulesCalled);
            }
            currentToken = tokens[0];
            Program();
            return (errors, rulesCalled);
        }

        private void Program(bool IsScope = false)
        {
            while (!currentToken.IsToken("EOF"))
            {
                if (currentToken.IsToken("DATATYPE"))
                    TrackFunction(Declaration, nameof(Declaration));
                else if (currentToken.IsToken("LOOP"))
                    TrackFunction(Loop, nameof(Loop));
                else if (currentToken.IsToken("if_stmt"))
                    TrackFunction(ConditionStmt, nameof(ConditionStmt));
                else if (currentToken.IsToken("return"))
                    TrackFunction(Func_Return, nameof(Func_Return));
                else if (currentToken.IsToken("ID"))
                    TrackFunction(Assign, nameof(Assign));
                else if (currentToken.IsToken("PRINT"))
                    TrackFunction(Print, nameof(Print));
                else if (IsScope)
                    return;

                else
                {
                    Error();
                    Consume();
                }
            }
        }

        private void Declaration()
        {
            if (currentToken.IsToken("DATATYPE"))
            {
                Match("DATATYPE");
                Match("ID");
                if (currentToken.IsToken("("))
                {
                    FunDeclaration();
                }
                else 
                {
                    VarDeclaration();
                }
            }
            else
            {
                Consume();
            }
        }

        private void Loop()
        {
            Match("LOOP");
            Match("(");
            Range();
            Match(")");
            Match("{");
            Program(true);
            Match("}");
        }

        private void ConditionStmt()
        {
            if (currentToken.IsToken("if_stmt"))
            {
                Match("if_stmt");
                Match("(");
                Condition();
                Match(")");
                Match("{");
                Program(true);
                Match("}");
            }

            if (currentToken.IsToken("else_stmt"))
            {
                Match("else_stmt");
                Match("{");
                Program(true);
                Match("}");
            }
        }

        private void Func_Return()
        {
           Match("return");
           Exp();
           Match("SEMICOLON");
        }
        private void Assign()
        {
            Match("ID");
            Match("ASSIGNOP");
            if (currentToken.IsToken("NUM"))
                Match("NUM");
            else
                AssignToVar();
            Match("SEMICOLON");
        }
        private void Print()
        {
            Match("PRINT");
            Match("(");
            Match("ID");
            Match(")");
            Match("SEMICOLON");
        }
        private void Range()
        {
            Exp();
            Match("RANGE");
            Exp();
        }

        private void Condition()
        {
            Exp();
            Match("COMPARISONOP");
            Exp();
        }

        private void AssignToVar()
        {
            Exp();
            if (currentToken.IsToken("SEMICOLON"))
                return;
            Match("(");
            Params(true);
            Match(")");
        }

        private void VarDeclaration()
        {
            if (currentToken.IsToken("ASSIGNOP"))
            {
                Match("ASSIGNOP");
                Exp();
                if (currentToken.IsToken("SEMICOLON"))
                {
                    Match("SEMICOLON");
                    return;
                }
                Match("(");
                Params(true);
                Match(")");
            }
            else if (currentToken.IsToken("["))
            {
                Match("[");
                Match("NUM");
                Match("]");
            }
            Match("SEMICOLON");
        }

        private void FunDeclaration()
        {
            Match("(");
            Params();
            Match(")");
            Match("{");
            Program(true);
            Match("}");
        }

        private void Params(bool IsAssign = false) {

            while (true)
            {
                if (!IsAssign)
                {
                    Match("DATATYPE");
                    Match("ID");
                }
                
                else
                {
                    if (currentToken.IsToken("ID"))
                        Match("ID");
                    else
                        Match("NUM");

                }
                if (currentToken.IsToken(")"))
                    break;
                else if (currentToken.IsToken("COMMA"))
                    Match("COMMA");
                else
                {
                    Match(")");
                    break;
                }
            }
        }
        private void Exp()
        {

            while (true)
            {
                if (currentToken.IsToken("ID"))
                    Match("ID");
                else
                    Match("NUM");

                if (currentToken.IsToken("MATHOP"))
                    Match("MATHOP");
                else if (currentToken.IsToken("BITSOP"))
                    Match("BITSOP");
                else
                    break;
            }
        }


    }
}
