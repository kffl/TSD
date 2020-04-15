# 1. Factorial
def factorialmethod(n)
    (1..n).inject(:*) || 0
end

# Factorial in integer
class Integer
    def factorial
        if self < 0
            raise "cannot count factorial for negative number"
        end
        factorialmethod(self)
    end
end

5.factorial
-1.factorial

# Square
module InstanceModule
    def square
        self ** 2
    end
end

class Integer
    include InstanceModule
end

5.square

# Sample
module ClassModule
    def sample(n)
        raise ArgumentError, "the value must be Integer" unless n.kind_of? Integer
        if n < 0
            raise ArgumentError, "the number must be positive"
        end
        r = []
        (1..n).each {r.append(rand(10))}
        r     
    end
    alias_method :random, :sample
end

class Integer
    extend ClassModule
end

Integer.sample(5)
Integer.sample(-1)

# Alias

Integer.random(5)
Integer.random(-1)
Integer.random(1.23)