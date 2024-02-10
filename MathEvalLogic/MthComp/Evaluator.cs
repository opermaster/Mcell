using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathEvalLogic.MthComp
{
    public class Evaluator
    {
        public readonly BinaryExpr root;
        public Evaluator(BinaryExpr root) {
            this.root = root;

        }
        private int EvaluateExpr(BinaryExpr node) {
            int left = 0;
            int right = 0;
            if (node.Left is Numeric n)
                left = n.Value;
            else if (node.Left is BinaryExpr bopl)
                left = EvaluateExpr(bopl);
            if (node.Right is Numeric b)
                right = b.Value;
            else if (node.Right is BinaryExpr bopr)
                right = EvaluateExpr(bopr);

            if (node.Left is Sin sin_n)
                left = Convert.ToInt32(Math.Sin(sin_n.Value));
            else if (node.Left is BinaryExpr bopl)
                left = EvaluateExpr(bopl);

            if (node.Left is Cos cos_n)
                left = Convert.ToInt32(Math.Cos(cos_n.Value));
            else if (node.Left is BinaryExpr bopl)
                left = EvaluateExpr(bopl);

            if (node.Left is Abs abs_n)
                left = Convert.ToInt32(Math.Abs(abs_n.Value));
            else if (node.Left is BinaryExpr bopl)
                left = EvaluateExpr(bopl);

            if (node.Left is Sqrt sqrt_n)
                left = Convert.ToInt32(Math.Sqrt(sqrt_n.Value));
            else if (node.Left is BinaryExpr bopl)
                left = EvaluateExpr(bopl);
            switch (node.Operator) {
                case "+":
                    left += right;
                    return left;
                case "-":
                    left -= right;
                    return left;
                case "/":
                    left /= right;
                    return left;
                case "*":
                    left *= right;
                    return left;
            }
            return left;
        }
        public int Eval() {
            return EvaluateExpr(root);
        }
    }

}
