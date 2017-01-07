# lambda & Proc.new
puts lambda {}
puts Proc.new {}

def a_method
  lambda { return 'returned by lambda.' }.call
  return 'a_method'
end

def b_method
  Proc.new { return 'returned by Proc.new.' }.call
  return 'b_method'
end

p a_method
p b_method


l = lambda { |a, b| a+b }
l = ->(a, b) { a+b }

p = Proc.new { |a, b| a+b }
p = proc { |a, b| a+b }

p BasicObject.superclass
puts (Float.instance_methods - Object.instance_methods).count
p 1.nil?

def is_ancestor(ancestor, current)
  temp = current
  while !temp.superclass.nil? && temp!=ancestor
    temp = temp.superclass
  end

  temp == ancestor
end

puts 1.nil? ? 1 : 0
a = is_ancestor(Object, String) ? 'yes' : 'No'
p a


# <editor-fold desc="bool test">
class BoolTest
  def test(a, b)
    a==b
  end

  def test?()
    '123'
  end
end
# </editor-fold>

p BoolTest.new.test?()