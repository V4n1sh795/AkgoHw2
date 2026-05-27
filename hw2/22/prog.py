
def unpack(string):
    multiply, symbol, result = [], [], []
    for char in string:
        if char.isnumeric():
            multiply.append(int(char))
            continue
        if char == '[':
            symbol.append([])
            continue
        if char == ']':
            if len(symbol) == 1:
                result.append(''.join(symbol.pop()) * multiply.pop())
                continue
            previous = ''.join(symbol.pop())
            symbol[-1].append(previous * multiply.pop())
            continue
        if len(symbol) == 0:
            result.append(char)
            continue
        symbol[-1].append(char)

    return ''.join(result)


def max_prefix():
    n = int(input())

    if n == 0:
        return ''

    prefix = unpack(input())
    for _ in range(n-1):
        string = unpack(input())
        while string[:len(prefix)] != prefix and prefix:
            prefix = prefix[:-1]

    return prefix

s = max_prefix()
print(len(s))
print(s)