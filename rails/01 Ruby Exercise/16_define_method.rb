class Doctor
  define_method("say") do |arg,*a|
    puts arg
  end
  def say1(a,b)

  end
end

Doctor.new.say "hello"
puts Doctor.new.method("say1").arity
Module.const_get("Doctor").new.say(898)

Monk = Class.new
Monk.class_eval do
  def zen
    42
  end
end

p Module.const_get('Monk').new.zen

ZEN = 49
class Monk; end


p Monk.const_get('ZEN')