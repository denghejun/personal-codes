p [:test,:ss].inspect
puts "qwerwe#{1}"
puts "qwerwe\#{1}"
p (1...10).map { |n| n.to_s }
puts "sdfsf#{defined?(d).inspect}"
$everywhere = "123"
puts $everywhere

begin
raise "error"
ensure
p $@
p $0
  end