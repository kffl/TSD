# Clock
class Clock
    attr :hours, :minutes, :seconds
    def initialize(hours, minutes, seconds)
        @hours, @minutes, @seconds = hours, minutes, seconds
    end
    def print
        puts "The current time is #{@hours}:#{@minutes.to_s.rjust(2, "0")}:#{@seconds.to_s.rjust(2, "0")}"
    end
    def ==(other)
        return @hours == other.hours && @minutes == other.minutes && @seconds == other.seconds
    end
    def <=>(other)
        if @hours != other.hours
            return @hours <=> other.hours
        elsif @minutes != other.minutes
            return @minutes <=> other.minutes
        else
            return @seconds <=> other.seconds
        end
    end
    def >(other)
        return self.<=>(other) == 1
    end
    def <(other)
        return self.<=>(other) == -1
    end
    def +(mins)
        @minutes += mins
        if @minutes > 60
            @minutes -= 60
            @hours += 1
            if @hours > 24
                @hours -= 24
            end
        end
        return self
    end
    def -(mins)
        @minutes -= mins
        if @minutes < 0
            @minutes += 60
            @hours -= 1
            if @hours < 0
                @hours += 24
            end
        end
        return self
    end
end

clock = Clock.new(10, 0, 0)
clock.print  # The current time is 10:00:00
clock += 30
clock.print  # The current time is 10:30:00
clock == Clock.new(10, 30, 0)  # true
clock -= 30
clock == Clock.new(10, 0, 0)
clock > Clock.new(9, 30, 0)
clock < Clock.new(9, 30, 0)
clock <=> Clock.new(10, 0, 0)