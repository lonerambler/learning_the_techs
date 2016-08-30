# My C++ summary
## Variables and types
A _valid identifier_ is a sequence of one or more letters, digits, or underscore characters `_`. Identifiers shall
always begin with a letter. They can also begin with an underline character or contain two successive underscore
characters anywhere, but such identifiers are - on most cases - considered reserved for compiler-specific keywords or
external identifiers.
### Standard Reserved Keywords
```
alignas, alignof, and, and_eq, asm, auto, bitand, bitor, bool, break, case, catch,
char, char16_t, char32_t, class, compl, const, constexpr, const_cast, continue,
decltype, default, delete, do, double, dynamic_cast, else, enum, explicit, export,
extern, false, float, for, friend, goto, if, inline, int, long, mutable, namespace,
new, noexcept, not, not_eq, nullptr, operator, or, or_eq, private, protected, public,
register, reinterpret_cast, return, short, signed, sizeof, static, static_assert,
static_cast, struct, switch, template, this, thread_local, throw, true, try, typedef,
typeid, typename, union, unsigned, using, virtual, void, volatile, wchar_t, while,
xor, xor_eq
```
Specific compilers may also have additional specific reserved keywords.

### Fundamental data types
The portions of the type names in _italics_ are optional.
| Group                    | Type names               | Notes on size / precision                            |
| ----------------------   | ------------------------ | ---------------------------------------------------- |
| Character types          | char                     | Exactly one byte in size. At least 8 bits.           |
|                          | char16_t                 | Not smaller than `char`. At least 16 bits.           |
|                          | char32_t                 | Not smaller than `char16_t`. At least 32 bits.       |
|                          | wchar_t                  | Can represent the largest supported character set.   |
| Integer types (signed)   | signed char              | Same size as `char`. At least 8 bits.                |
|                          | _signed_ short _int_     | Not smaller than `char`. At least 16 bits.           |
|                          | _signed_ int             | Not smaller than `short`. At least 16 bits.          |
|                          | _signed_ long _int_      | Not smaller than `int`. At least 32 bits.            |
|                          | _signed_ long long _int_ | Not smaller than `long`. At least 64 bits.           |
| Integer types (unsigned) | unsigned char            | (same size as their signed counterparts)             |
|                          | unsigned short _int_     |                                                      |
|                          | unsigned _int_           |                                                      |
|                          | unsigned long _int_      |                                                      |
|                          | unsigned long long _int_ |                                                      |
| Floating-point types     | float                    |                                                      |
|                          | double                   | Precision not less than `float`                      |
|                          | long double              | Precision not less than `double`                     |
| Boolean type             | bool                     |                                                      |
| Void type                | void                     | no storage                                           |
| Null pointer             | decltype(nullptr)        |                                                      |

The properties of fundamental types in a particular system and compiler implementation can be obtained by
using the `numeric_limits` classes (see standard header `<limits>`). If for some reason, types of specific
sizes are needed, the library defines certain fixed-size type aliases in header `<cstdint>`.

### Variables and initialization

* _c-like initialization:_ `type identifier = initial_value;`
* _constructor initialization:_ `type identifier (initial_value);`
* _uniform initialization:_ `type identifier {initial_value};`

Powerful features recently added to the language, meant to be used either when the type cannot
be obtained by other means or when using it improves code readability (not in this case)
* _type deduction (auto):_ `int foo = 0; auto bar = foo; // bar is and int (as foo) and its value is that of foo`
* _type deduction (decltype):_ `int foo = 0; decltype(foo) bar; // bar have the same type of foo`

## Constants
### Literals
Literal constants can be classified into: integer, floating-point, characters, strings, Boolean, pointers, and
user-defined literals.

### Integer Numerals
Numerical constants that identify integer values, decimal (`75`), octals are preceded by a `0` character (`0113`)
and hexadecimals are preceded by the `0x` sequence (`0x4b`).

We can add a type to these constants as case-insensitive suffixes, just like we create variables. `unsigned` is get
by `u` or `U`, `long` requires `l` or `L`, double this last one (`ll` or `LL`) to make it `long long`. As expected
they can be combined, and if none is added, the default value is `int`: `75`, `75u`, `75l` & `75ul` all are different
representations of the same number (seventy-five), they just vary in the amount of consumed memory.

### Floating Point Numbers
A literal containing one or both of decimal point `.` or _by ten at the Xth height_ character `e`, it'll represent
a floating point number, we have also case-insensitive type modifiers of the default (`double`), as expected. `f` or
`F` stores the number as `float` value, while `l` or `L` forces `long double`.

### Character and string literals
Values within single quotes (should be just one character, like in `'x'`) represent _character_ literals, double
quoted literals represent strings (`"world"`).

Certain characters can be specified with backslash (`\`) scape codes, including the backslash itself:
`\n \r \t \v \b \f \a \' \" \? \\`

Also, every character can be specified as a backslash-ed scape sequence if its octal or hexadecimal representation
is known. The former use a `\##` form (no need of begin with `0`), the later use instead `\x##`.

Several strings separated by blank spaces (tab, whitespace, newline) will be automatically concatenated. Also, within
a single string, a backslash at the end of the line allow a string be continued in the next line.

By default, char and string literals are made of `char`s, we can prefix the literals with the **case-sensitive** `u`,
`U` and `L` to made them of `char16_t`, `char32_t` and `wchar_t`, respectively.

Finally, the last 2 modifier prefixes are:
* `u8` that will encode the string in the executable using UTF-8.
* `R"sequence(` that will start a _raw_ string where every character is valid till the `)sequence"` closing mark.

### Other literals
* `true` and `false` are the two possible values for variables of type `bool`.
* `nullptr` is the _null pointer_ value.

### Typed constant expressions
Prepending a type declaration with `const` like in `const double pi = 3.14159;` allow us to simply just use the value
later without caring it as a variable, is a matter of convenience.

### Preprocessor definitions (`#define`)
`#define identifier replacement`
Any instance found of _identifier_ will effectively replace it by _replacement_, where _replacement_ is everything till
the end of line, it's a _blind replacement_, no checks are performed, `;` is not required, if `;` is added, it'll be
part of the replacement.
