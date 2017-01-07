class Item
  @@item_count = 0
  @item_number= '999'
  attr_accessor :item_number, :item_desc

  def initialize(item_number,item_desc)
    @item_number = item_number
    @item_desc = item_desc
    @@item_count+=1
  end

   def showDesc
    puts "#{self.item_number},#{self.item_desc}"
  end


  # region static method of class
  class << self
    attr_accessor :item_number,:item_count
    public :item_count=
    def show
      puts 'item show.'
    end

    public :show
  end
# endregion

  # region public,private,protected
  public :showDesc
# endregion

end

item = Item.new('11-119-084','this is a short desc.')
p item.item_number,item.item_desc
item.item_number = '00-000-000'
item.showDesc
Item.show
Item.new('11-119-084','this is a short desc.')
Item.new('11-119-084','this is a short desc.')
Item.item_count = 100000
p Item.item_count
Item.item_number = '1111'
p Item.item_number
