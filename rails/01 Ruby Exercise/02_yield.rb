# test the performance
require('benchmark')

def temp_puts(a,b)
  p "the result is #{yield(a,b)}"
end

temp_puts(1,2) {|a,b| a+b+1 }

# 标准检测 性能测试
def explicit(a,b,&proc)
  proc.call(a,b)
end

# or
# def explicit(a,b,proc)
#   proc.call(a,b)
# end
# p explicit(1,2,lambda{|a,b| a+b})

p explicit(1,2) {|a,b| a+b}

def implicit(a,b)
  yield(a,b)
end

Benchmark.bmbm(10) do |report|
  report.report('explicit') do
    1000.times do
      explicit(1,5,&lambda{|a,b| a+b})
    end
  end

  report.report('implicit') do
    implicit(1,5) {|a,b| a+b}
  end
end