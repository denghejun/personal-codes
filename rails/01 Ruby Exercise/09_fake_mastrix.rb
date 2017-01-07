CONSTCHARS = ['A','B','C','D']
p CONSTCHARS.product(CONSTCHARS).reject {|e| e.first == e.last} .transpose

p [[1,2,7],[3,4,5]].transpose