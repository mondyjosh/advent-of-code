use std::error::Error;
use std::fs;
use std::path::PathBuf;

use config::Config;
use solutions::Solution;

mod solutions;

// TODO: Better name
pub struct AocConfig {
    pub year: u32,
    pub day: u32,
    pub input_file_path: String,
}

impl AocConfig {
    pub fn build(mut args: impl Iterator<Item = String>) -> Result<AocConfig, &'static str> {
        // Ignore arg[0] (binary name)
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

        Ok(AocConfig {
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

pub fn run(config: AocConfig) -> Result<(), Box<dyn Error>> {
    let input = fs::read_to_string(config.input_file_path)?;

    // TODO: Figure out a non-panic version of this
    let solution = match solutions::get_solution(config.year, config.day) {
        Some(s) => s,
        None => panic!("No solution found"),
    };

    println!(
        "🎅 Running {}-{}: {}\r\n",
        format!("{:04}", &config.year).as_str(),
        format!("{:02}", &config.day).as_str(),
        solution.name()
    );

    println!("🌟 Part 1: {}", solution.solve_part_1(&input));
    println!("🌟 Part 2: {}", solution.solve_part_2(&input));
    println!("\r\n🎄 Christmas is one day closer to being saved!");

    Ok(())
}
