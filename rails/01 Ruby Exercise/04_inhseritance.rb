class Rectangle
  def initialize(length,width)
    @length = length
    @width = width
  end

  def perimeter
    2 * (@length + @width)
  end

  def area
    @length * @width
  end
end

# region 1. inheritance
# class Square < Rectangle
#   def initialize(side)
#     @length = side
#     @width = side
#   end
# end
# endregion

# region 2. redefine method
# class Rectangle
#   def perimeter
#
#   end
# end
# endregion

# region 3. overriding method
# the Square#initialize is a demo.
# endregion

# region 4. super (base.method...)
class Square < Rectangle
  def initialize(side)
    super(side,side)
  end
end
# endregion


p Square.new(5).perimeter()