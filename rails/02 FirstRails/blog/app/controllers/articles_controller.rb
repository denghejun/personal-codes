class ArticlesController < ApplicationController
  http_basic_authenticate_with name: "admin", password:"123456",except: [:index,:show]
  def index
    # test = "12 OR 1=1" # do not like this
    # @articles = Article.where("text=#{test}")

    # test = "12 OR 1=1" # you should like this
    # @articles = Article.where("text=?",test)
     pageSize = 5
     currentPage = 2
     @articles =  Article.limit(pageSize).offset((currentPage-1)*pageSize)
  end

  def show
    @article = Article.find(params[:id])
  end

  def new
     @article = Article.new # 为了保证在渲染View时，@article不为nil。
  end

  def edit
    @article = Article.find(params[:id])
    # render plain: params
  end

  def temp_out
    render plain: "this is a temp plain text." # the "plain" option means will just respond plain text, rather than *.html.erb
    # the "plain" just a response format.
  end

  def update
    @article = Article.find(params[:id])
    if(@article.update(params.require(:article).permit(:text,:title)))
      redirect_to @article
    else
      render "edit"
    end
  end

  def destroy
    @article = Article.find(params[:id])
    @article.destroy if !@article.nil?
    redirect_to articles_path
  end

  def create
  @article = Article.new(params.require(:article).permit(:text, :title)) # return a property hash to New.
    if @article .save
       redirect_to @article # use the model @article's name as a route url. amd pass the model @article to view.
    else
      render "new" # 直接开始渲染View，此时的@article.errors 会包含错误信息。并不会重新路由到articles#new.
    end

  end
end
