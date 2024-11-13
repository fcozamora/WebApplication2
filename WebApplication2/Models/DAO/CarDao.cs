using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models.DTO;

namespace WebApplication2.Models.DAO
{
    public class CarDao
    {
        public List<CarDto> ReadCars()
        {
           List<CarDto> cars = new List<CarDto>();

            try
            {
                using (var connection = Cnx.getCnx())
                {
                    connection.Open();
                    string query = "SELECT * FROM Car";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        CarDto car = new CarDto()
                        {
                            CarID = reader.GetInt32("CarId"),
                            Make = reader.GetString("Make"),
                            Model = reader.GetString("Model"),
                            Year = reader.GetInt32("Year"),
                            Price = reader.GetInt32("Year"),
                            DateAdded = reader.GetDateTime("DateAdded")
                        };
                        cars.Add(car);
                    }                    

                    connection.Close();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"An error ocurred: {ex.Message}");
            }

            return cars;
        }
        public CarDto ReadCarById(int carId)
        {
            CarDto car = new CarDto();
            try
            {
                using (var connection = Cnx.getCnx())
                {
                    connection.Open();
                    string query = "SELECT * FROM car WHERE CarID = @carId";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@carId", carId);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        car.CarID = reader.GetInt32("CarId");
                        car.Make = reader.GetString("Make");
                        car.Model = reader.GetString("Model");
                        car.Year = reader.GetInt32("Year");
                        car.Price = reader.GetInt32("Year");
                        car.DateAdded = reader.GetDateTime("DateAdded");
                    }

                    connection.Close();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"An error ocurred: {ex.Message}");
            }

            return car;
        }
        public string CreateCar(CarDto car)
        {
            string res = "Failed";

            try
            {
                using (var connection = Cnx.getCnx())
                {
                    connection.Open();
                    string query = "INSERT INTO car (Make, Model, Year, Price, DateAdded) Values (@make, @model, @year, @price, @dateAdded)";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@make", car.Make);
                    cmd.Parameters.AddWithValue("@model", car.Model);
                    cmd.Parameters.AddWithValue("@year", car.Year);
                    cmd.Parameters.AddWithValue("@price", car.Price);
                    cmd.Parameters.AddWithValue("@dateAdded", DateTime.Now);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0) res = "Success";
                    connection.Close();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"An error ocurred: {ex.Message}");
            }

            return res;
            
        }
    }
}