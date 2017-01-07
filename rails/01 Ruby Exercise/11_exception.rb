def warning
  # fail("wrong!")
  # raise Exception.new("something error!")
  raise(StandardError, "Raising standard error")
  raise(ArgumentError, "Raising standard error")
  raise(IndexError, "Raising standard error")
end
def warning_v2
  raise Exception.new("something error v_2 !")
end

def test
  warning
  warning_v2
  rescue StandardError => e
    puts "everything is ok! but #{e.message}"
  ensure
    puts "we will fix it."
end

test

unless 1==2
  p '123'
end
