def foo(*args)
  p args
end

p [1,2,3].build

foo(1,2)
foo 1,2,3
foo a:3
foo a:4,b:5
foo ({a:6,b:7})
foo ({a:8,b:9}),({c:10})

hash = {a:1,b:2}
puts hash[:b]

puts 1==1
puts 1.eql? 1
puts 1.equal? 1

text = "1"
puts text == "1"
puts text.eql? "1"
puts text.equal? 1

