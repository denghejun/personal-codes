p [1,2].each
class Array
  def map_with_index(&block)
    self.each_with_index.map(&block)
  end
end
[9,2,3].map_with_index do |e,i|
  puts e+i
end

module Math
  def self.f
    PI
  end

  def f
    PI
  end
end

class Test
  extend Math
end

p Test.f

puts (["1",23,2].all? { |e| e.class == String }) ? "yes":"No"

p [1,2,3,1] | [2,4]
p [1,2,3,1] - [2,4]
p [1,2,3,1] & [2,4]

