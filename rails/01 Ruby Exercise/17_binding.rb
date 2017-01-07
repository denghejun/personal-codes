class Foo
  def get_binding
    bar = "flower"
    binding
  end
end

puts eval("bar",Foo.new.get_binding)

# puts __FILE__

# puts __LINE__
p eval("2322",binding,__FILE__,__LINE__)

require "Benchmark"
Benchmark.bmbm do |x|

end

puts eval("1")

