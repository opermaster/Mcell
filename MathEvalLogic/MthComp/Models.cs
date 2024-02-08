namespace MathEvalLogic.MthComp
{
    public class Token
    {
        public TokenType Type;
        public string Value;
        public Token(TokenType type, string value) {
            Type = type;
            Value = value;
        }
    }
    public enum TokenType
    {
        Num,
        Op,
        End,
        Sin,
        Cos,
        Abs,
        Sqrt,

    }

    public class Expr { }
    public sealed class Numeric : Expr
    {
        public int Value { get; }
        public Numeric(int Value) {
            this.Value = Value;
        }

    }
    public sealed class Sin : Expr
    {
        public int Value { get; }
        public Sin(int Value) {
            this.Value = Value;
        }

    }
    public sealed class Cos : Expr
    {
        public int Value { get; }
        public Cos(int Value) {
            this.Value = Value;
        }

    }
    public sealed class Abs : Expr
    {
        public int Value { get; }
        public Abs(int Value) {
            this.Value = Value;
        }

    }
    public sealed class Sqrt : Expr
    {
        public int Value { get; }
        public Sqrt(int Value) {
            this.Value = Value;
        }

    }
    public sealed class BinaryExpr : Expr
    {
        public Expr Left;
        public Expr Right;
        public string Operator;

        public BinaryExpr(Expr left, Expr right, string op) {
            Left = left;
            Right = right;
            Operator = op;
        }
    }
}
