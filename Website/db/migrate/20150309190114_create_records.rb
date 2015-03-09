class CreateRecords < ActiveRecord::Migration
  def change
    create_table :records do |t|
      t.string :email
      t.integer :level
      t.integer :time
      t.integer :score
      t.integer :clicks

      t.timestamps null: false
    end
  end
end
