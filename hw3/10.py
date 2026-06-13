# https://acmp.ru/?main=task&id_task=478 

import sys
# Чтение всех данных из стандартного ввода
input_data = sys.stdin.read().split()
    
it = iter(input_data)
N = int(next(it))

sheets = []
for i in range(N):
    a = float(next(it))
    b = float(next(it))
    sheets.append((a, b, i + 1))

sheets.sort(key=lambda x: x[0] / x[1], reverse=True)


left, right = 0, N - 1
time_A = time_B = 0.0
cur_A = cur_B = 0.0  

while left <= right:
    if left == right:
        a_val, b_val = sheets[left][0], sheets[left][1]
        rate_A = 1.0 / a_val
        rate_B = 1.0 / b_val
        dt = (1.0 - cur_A - cur_B) / (rate_A + rate_B)
        T = time_A + max(0.0, dt) 
        break

    t_A = (1.0 - cur_A) * sheets[left][0]
    t_B = (1.0 - cur_B) * sheets[right][1]

    if t_A <= t_B:
        dt = t_A
        time_A += dt
        time_B += dt
        cur_A = 0.0
        left += 1
        if left <= right:
            cur_B += dt / sheets[right][1]
            if cur_B > 1.0: cur_B = 1.0
    else:
        dt = t_B
        time_A += dt
        time_B += dt
        cur_B = 0.0
        right -= 1
        if left <= right:
            cur_A += dt / sheets[left][0]
            if cur_A > 1.0: cur_A = 1.0

# Вывод результатов
sys.stdout.write(f"{T:.4f}\n")
sys.stdout.write(" ".join(str(s[2]) for s in sheets) + "\n")
