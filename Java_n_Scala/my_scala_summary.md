- Operators and functions are evaluated similarly (left to right), this follows the "substitution model",
  whose main idea is that all evaluation does is reduce expression to a value. Reduces the arguments to
  values before rewriting them. This is called call-by-value.
  Adv: Evaluates every argument only once

- Alternatively, one can pass the arguments, that is, apply the function to unreduced arguments.
  This is called call-by-name.
  Adv: Argument is not even evaluated if not used in body

- Theorem:
    If CBV of expression e terminates, then CBN terminates too.
    The other direction is not true
        - Scala normally uses CBV
        - "=>" makes arguments CBN. e.g. "def constOne(x: Int, y: => Int) = 1"

- Conditionals look like Java's if-else but is used for expressions not statements
    e.g. def abs(x: Int) = if (x >= 0) x else -x
                               ^^^^^^
                               predicate

        !true       --->    false
        !false      --->    true
        true  && e  --->    e
        false && e  --->    false
        true  || e  --->    true
        false || e  --->    e

def function([name: [=>] Type[, ...]])[: ReturnType] = content
                                                                *** Primitives as in Java but capitalized ***
e.g.: def square(x: Double        )         = x * x                 Int, Double, Boolean
      def power (x: Double, y: Int): Double = ...
