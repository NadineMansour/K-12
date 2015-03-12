class Api::RecordsController < Api::BaseController
	def get_records_by_email
		@email = params[:email]
		#logic goes here to get @records
		@records = Record.where(email: @email) ### code here
		respond_with @records
	end


	def save_record
		@time = params[:time]
		@score = params[:score]
		@level = params[:level]
		@clicks = params[:clicks]
		@email = params[:email]
		@record = Record.new(time: @time, score: @score, level: @level, clicks: @clicks, email: @email)
		if @record.save ##logic
			render status: 201
		else
			render status: 402
		end

	end

	def get_level
		@email = params[:email]
		@records = Record.where(email: @email)
		@record = @records.last
	end

end