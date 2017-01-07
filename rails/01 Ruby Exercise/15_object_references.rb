a = "1"
puts a.object_id
b = "2"
arr = [a,b]
a = "1"
puts a.object_id

def f
  p caller
end

require "logger"
log = Logger.new("log.txt")
log.error("this is a log 3.")
p f.class

require("benchmark")
puts Benchmark.measure {1.times{puts "12313123"}}


def func

end

puts self.method("func").class

class Foo
  def method_missing(sys,*args,&block)
    puts "missing"
  end
end

foo=Foo.new
p foo.send("object_id")  # this is same as foo.object_id
# p foo.kkl(999) {1}

puts Foo.superclass.superclass.superclass

def test(*args)
  p args
end


test 1

