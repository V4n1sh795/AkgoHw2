N = int(input())
max_sum = 0
sum1 = 0
for i in range(N):
    sum1 += int(input())
    if sum1 > max_sum:
        max_sum = sum1
    elif sum1 < 0:
        sum1 = 0
print(max_sum)