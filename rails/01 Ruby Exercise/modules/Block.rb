module Block
  def func
    p '123'
  end

  def delegate(a,b)
    # yield(a,b) if block_given?
    block_given?? yield(a,b) : 404
  end
end