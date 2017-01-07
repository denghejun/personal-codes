module Utility
  def self.included(included_class) # As you can see, this is a callback by ruby.
     puts "Utility Module has been included in class #{included_class}"
  end
  def instance_method_call
    puts "instance_method invoked."
  end
end

class Biz
  # include Utility
end

# the instance method include in Biz instance
newBiz = Biz.new
newBiz.extend Utility
newBiz.instance_method_call

# the class method extend from Utility Module
Biz.extend Utility
Biz.instance_method_call



module Foo
  module ClassMethods
    def self.included(base)
      puts self.to_s
      base.extend self
      puts base.to_s
    end
    def self.extended(base)
      puts "ClassMethods has been extended with class #{base}"
    end

    def guitar
      "gently weeps"
    end
  end
end

class Bar
  include Foo::ClassMethods
end

puts Bar.guitar
puts Bar.new.guitar

p Foo::ClassMethods.included(nil)