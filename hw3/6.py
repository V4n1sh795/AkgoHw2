# https://acmp.ru/index.aspmain=task&id_task=228

N = int(input())
r = 100.0
d = 0.0
e = 0.0
for i in range(N):
    cur_d, cur_e = map(float , input().split(" "))
    per_day_r = max(r, d * cur_d, e * cur_e)
    per_day_d = max(d, r / cur_d, e * cur_e / cur_d)
    per_day_e = max(e, r / cur_e, d * cur_d / cur_e)

    r = per_day_r
    d = per_day_d
    e = per_day_e

print(r)