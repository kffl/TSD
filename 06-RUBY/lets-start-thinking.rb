# Min-Max Sum

def min_max(arr)
    sorted = arr.sort
    last_el = sorted.last
    sorted.pop()
    s_min = sorted.inject(0, :+)
    s_max = s_min - sorted.first + last_el
    puts "%d %d" % [s_min, s_max]
end

min_max([1, 2, 3, 4, 5])  # 10 15
min_max([2, 8, 3, 5, 1])  # 11 18

# Decimal

def decimal(s)
    r = 0
    s.each_char do |l|
        r = r * 2
        if l == '1'
            r = r + 1
        elsif l != '0'
            raise ArgumentError, "this is not a binary number"
        end
    end
    return r
end

decimal("101")  # 5
decimal("1111110")
decimal("231")  # ArgumentError: this is not a binary number