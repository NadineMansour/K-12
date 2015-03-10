class CreateStudents < ActiveRecord::Migration
  def change
    create_table :students do |t|

    	t.string :school
    	t.string :student_class
    	t.string :grade
    	t.string :student_name
        t.timestamps null: false
    end
  end
end
