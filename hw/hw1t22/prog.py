from collections import defaultdict

def main():
    n = int(input())
    billionaires = {}
    current_city = {}
    wealth = {}
    
    for _ in range(n):
        name, city, money = input().split()
        money = int(money)
        billionaires[name] = (city, money)
        current_city[name] = city
        wealth[name] = money
    
    m, k = map(int, input().split())
    
    # Keep on rolling, rolling, rolling
    moves_by_day = defaultdict(list)
    for _ in range(k):
        day, name, city = input().split()
        day = int(day)
        moves_by_day[day].append((name, city))
    
    leader_days = defaultdict(int)
    
    # city state
    city_wealth = defaultdict(int)
    for name in billionaires:
        city = current_city[name]
        city_wealth[city] += wealth[name]
    # going by days
    for day in range(1, m + 1):
        if day > 1 and (day - 1) in moves_by_day:
            for name, new_city in moves_by_day[day - 1]:
                if name in billionaires:
                    old_city = current_city[name] 
                    w = wealth[name]
                    city_wealth[old_city] -= w
                    current_city[name] = new_city
                    city_wealth[new_city] += w
        
        # leaders
        if city_wealth:
            max_wealth = max(city_wealth.values())
            # Povtori
            leaders = [city for city, w in city_wealth.items() if w == max_wealth]
            if len(leaders) == 1:
                leader_days[leaders[0]] += 1
    
    # results
    for city in sorted(leader_days.keys()):
        print(city, leader_days[city])

if __name__ == "__main__":
    main()