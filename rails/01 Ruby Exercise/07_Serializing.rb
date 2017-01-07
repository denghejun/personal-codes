require 'YAML'
class Item
  @@item_cache_file = 'item_cache.yaml'
  attr_accessor :item_number, :item_desc
  def initialize(item_number, item_desc)
    @item_number = item_number
    @item_desc = item_desc
  end

  def serialize
   yaml_string = YAML::dump(self)
   File.open(@@item_cache_file,'w') do |file|
     file.write yaml_string
   end
  end

  def self.deserialize
    File.open(@@item_cache_file,'r') do |file|
      YAML::load file.read.to_s
    end
  end
end

puts Item.new('1','2').serialize
obj = Item.deserialize()
puts obj.item_number