def main():
    n = int(input())
    s1 = input()
    s2 = input()
    s1 += s1
    pos = s1.find(s2)
    print(pos)
    if pos == -1:
        print(-1)
    elif pos == 0:
        print(0)
    else:
        print(n - pos)

if __name__ == "__main__":
    main()
# abracadabraabracadabra
#   racadabraab
# pos = 2