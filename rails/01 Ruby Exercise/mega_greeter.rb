class MegaGreeter
  # properties
  attr_accessor :names

  # constructor
  def initialize(names = 'World')
    @names = names
  end

  # methods
  def say_hi
    if @names.nil?
      puts '...'
    elsif @names.respond_to?('each')
      @names.each do |name|
        puts "hello #{name}"
      end
    else
      puts "hello #{@names}"
    end
  end

  def say_bye
    if @names.nil?
      puts '...'
    elsif @names.respond_to?('join')
      puts "goodbye #{@names.join(',')}, come back soon."
    else
      puts "goodbye #{@names},come back soon."
    end
  end
end

# if execute this file,the codes below will be executed, other(only reference this file as a lib.) will not be executed.
if __FILE__ == $0

  #1.class
  person = MegaGreeter.new([1,2,3])
  person.say_hi
  person.say_bye
  ###############

  #2. lambda
  l = lambda do |a, b|
     a+b

  end
  puts l.call(3,2)

  l =-> (a,b) { return a*b }
  puts l.call(3,2)

  l= lambda do |a,b|
    a+b
    c=a+a+a
  end

  puts l.call(5,5)
  #############

  #3. Module
  module TestModule
    def test
      puts 'test module function.'
    end
  end

  class Test
    include TestModule

  end

  Test.new.test()
  puts Test.class
  puts Test.new.class
  puts TestModule.class

  # extend methods like C#.
  module Perimeter
    def perimeter(number)
      number.inject(5) {|sum,n| sum + n}
    end
  end

  class Rectangle
    include Perimeter
    def initialize(length, breadth)
      @length = length
      @breadth = breadth
    end

    def sides
      [@length, @breadth, @length, @breadth]
    end
  end

  class Square
    include Perimeter
    def initialize(side)
      @side = side
    end

    def sides
      [@side, @side, @side, @side]
    end
  end

  # puts Rectangle.new(2,3).sides
 puts Rectangle.new(2,3).perimeter([1,2])

  module Names
    def fun(name)
      @name =name
    end
    class Array
      def To
        puts 'to'
      end
    end
  end

  class Array
    def To
      puts 'to'
    end
  end

  # puts '1 2 3'.split(' ')
  puts IO.new(IO.sysopen('new.md','w'))

  ###################

  File.open("D:\\Sync Object.txt",'r+') { |file|
    buffer = ''
    buffer1 = ''

    p file.read
    file.read(10,buffer)
    file.rewind
    file.read(10,buffer1)
    puts buffer
    puts buffer1
    file.seek(0,IO::SEEK_SET)
    file.write('11')
    p file.readlines()[0]
    file.close()
  }

end

