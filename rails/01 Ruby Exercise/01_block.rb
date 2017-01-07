require_relative 'modules/Block'
class BlockClass
  include Block
end

if __FILE__ == $0
  BlockClass.new.func
  BlockClass.new.method('func').to_proc.call
  p BlockClass.new.delegate(2,3) {|a,b|a*b}
  p BlockClass.new.delegate(2,3)
end