use std::error::Error;
use std::fs;
use std::path::PathBuf;

use config::Config;

use problem::Solution;
mod problem;
mod solutions;

pub struct AocConfig {
    pub year: u32,
    pub day: u32,
    pub file_path: String,
}

impl AocConfig {
    pub fn build(mut args: impl Iterator<Item = String>) -> Result<AocConfig, &'static str> {
        // ignore arg[0] (binary name)
        args.next();

        // TODO: Check if Year and Day are integers
        let year = match args.next() {
            Some(arg) => arg.parse::<u32>().unwrap(),
            None => return Err("Didn't get a year"),
        };

        let day = match args.next() {
            Some(arg) => arg.parse::<u32>().unwrap(),
            None => return Err("Didn't get a day"),
        };

        let config = Config::builder()
            .add_source(config::File::from(PathBuf::from("./Settings")))
            .build()
            .unwrap();

        // TODO: Improve file_path assembly
        let template = &config.get::<String>("input_file_path_template").unwrap();
        let year_string = format!("{:04}", &year);
        let day_string = format!("{:02}", &day);
        let file_path = template
            .replace("{year}", &year_string)
            .replace("{day}", &day_string);

        // TODO: Improve/understand Solution selector
        let solutions = solutions::get_year(year);
        let solution = match solutions.get(day as usize) {
            Some(s) => s,
            None => {
                // TODO: Include day and year in Err
                return Err("No solution for day-year combo");
            }
        };

        // TODO: move solution outside lifetime of build
        let part_one = solution.solve_part_1(String::from("input"));
        let part_two = solution.solve_part_2(String::from("input"));

        println!("Part 1: {}", part_one);
        println!("Part 2: {}", part_two);

        Ok(AocConfig {
            year,
            day,
            file_path,
        })
    }
}

pub fn run(config: AocConfig) -> Result<(), Box<dyn Error>> {    
    // println!("[*] Running: {} ", solution.name());

    // TODO: Include filename in error if missing
    let contents = fs::read_to_string(config.file_path)?;

    let results: Vec<&str> = contents.lines().collect();

    // TODO: Add solution runner harness
    // solution.solve_part_1(contents);

    // TODO: Remove once the runner harness is implemented
    // for line in results {
    //     println!("{line}");
    // }

    Ok(())
}
