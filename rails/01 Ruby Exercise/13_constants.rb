module Test

end

Test::A = 90
puts Test::A

fence = Module.new do
  def speak
    "I'm trapped!"
  end
end

class Sheep
  def speak
    "Baaaaahhhhh."
  end
end

dolly = Sheep.new
puts dolly.speak
dolly.extend(fence)
puts dolly.speak

# generate a new class from a method
def create_class
  generated_class = Class.new do
    def speak
     puts "hello!"
    end
  end
end

c = create_class
c.new.speak

# define a class in module
module Create_Class
  Sheep = Class.new do
    def speak
      puts "hhhhh"
    end
  end
end

Create_Class::Sheep.new.speak