class Item
  attr_reader :item_number, :item_desc
  def initialize(item_number, item_desc)
    @item_number = item_number
    @item_desc = item_desc
  end

  def ==(other_item)
    @item_number == other_item.item_number &&
    @item_desc == other_item.item_desc
  end

  def eql?(other_item)
    self == other_item
  end

  def hash
    @item_number.hash ^ @item_desc.hash
  end

  def  to_s
    "to_S: #{@item_number}, #{@item_desc}"
  end

end

items = [Item.new('1','1'),Item.new('1','2'),Item.new('1','1')]
p items.uniq

item =  Item.new('1','2')
p item
puts item
