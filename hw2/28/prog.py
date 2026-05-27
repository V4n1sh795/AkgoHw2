lentgh = int(input())
str1 = input()
str2 = input()
#       racadabr
str1copy = str1
indexof = []
messengermax = -1
if str1 == str2:
    print(0)
else:
    for i in range(str1.count(str2[0])):
        ind = str1.index(str2[0])
        indexof.append(ind)
        str1copy = str1copy.replace(str1[ind], "♫", 1) 
        
    for index in indexof:
        for i in range(index, lentgh*2):
            if str2[0: i-index] == str1[index: i]:
                if len(str2[0: i-index]) > messengermax:
                    messengermax = len(str2[0: i-index])
    print(messengermax)