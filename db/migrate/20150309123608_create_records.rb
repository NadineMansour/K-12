class CreateRecords < ActiveRecord::Migration
  def change
    create_table :records do |t|
      t.string :e-mail
      t.int :level
      t.int, :time
      t.int, :score
      t.string :clicks
      t.string :int

      t.timestamps null: false
    end
  end
end
