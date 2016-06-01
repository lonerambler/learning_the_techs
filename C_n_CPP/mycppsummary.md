# My C++ summary
## Variables and types
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

### Fundamental data types
| Group                    | Type names*              | Notes on size / precision                            |
| ----------------------   | ------------------------ | ---------------------------------------------------- |
|Character types           | char                     | Exactly one byte in size. At least 8 bits.           |
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

