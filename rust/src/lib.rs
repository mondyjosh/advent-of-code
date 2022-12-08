use std::error::Error;
use std::fs;
use std::path::PathBuf;

use config::Config;
use solutions::Solution;

mod solutions;

pub struct AppConfig {
    pub year: u32,
    pub day: u32,
    pub input_file_path: String,
}

impl AppConfig {
    pub fn build(mut args: impl Iterator<Item = String>) -> Result<AppConfig, &'static str> {
        // Don't need arg[0] (binary name)
        args.next();

        let year = match args.next() {
            Some(arg) => arg.parse::<u32>().unwrap(),
            None => return Err("Didn't get a year"),
        };

        let day = match args.next() {
            Some(arg) => arg.parse::<u32>().unwrap(),
            None => return Err("Didn't get a day"),
        };

        let input_file_path = build_input_file_path(year, day);

        Ok(AppConfig {
            year,
            day,
            input_file_path,
        })
    }
}

fn build_input_file_path(year: u32, day: u32) -> String {
    let config = Config::builder()
        .add_source(config::File::from(PathBuf::from("./Settings")))
        .build()
        .unwrap();

    let template = &config.get::<String>("input_file_path_template").unwrap();

    let input_file_path = template
        .replace("{year}", format!("{:04}", &year).as_str())
        .replace("{day}", format!("{:02}", &day).as_str());

    input_file_path
}

pub fn run(config: AppConfig) -> Result<(), Box<dyn Error>> {
    let solution = solutions::get_solution(&config.year, &config.day)?;
    let input = fs::read_to_string(config.input_file_path)?;

    println!(
        "🎁 Rust solution for AOC_{:04}_{:02}: {}\r\n",
        &config.year,
        &config.day,
        solution.name()
    );

    println!("🌟 Part 1: {}", solution.solve_part_1(&input));
    println!("🌟 Part 2: {}", solution.solve_part_2(&input));
    println!("\r\n🎄 Christmas is one day closer to being saved! 🎄");

    Ok(())
}
