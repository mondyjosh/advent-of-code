// use std::env;
use std::error::Error;
use std::fs;

pub struct Config {
    pub year: String,
    pub day: String,
    pub file_path: String,
}

impl Config {
    pub fn build(mut args: impl Iterator<Item = String>) -> Result<Config, &'static str> {
        // ignore arg[0] (binary name)
        args.next();

        // TODO: Parse Year and Day as integers
        let year = match args.next() {
            Some(arg) => arg,
            None => return Err("Didn't get a year"),
        };

        let day = match args.next() {
            Some(arg) => format!("{:02}", arg.parse::<i32>().unwrap()),
            None => return Err("Didn't get a day"),
        };

        // TODO: Determine a more idiomatic way to assemble Config.file_path
        let foo = String::from("../docs/year{year}/inputs/day{day}_input.txt");
        let bar = foo.replace("{year}", &year);
        let file_path = bar.replace("{day}", &day);

        // if !Path::new(file_path).exists() {
        //     return Err("File doesn't exist")
        // }

        // TODO: Specify which year+day solution to use and set in Config

        Ok(Config {
            year,
            day,
            file_path,
        })
    }
}

pub fn run(config: Config) -> Result<(), Box<dyn Error>> {
    
    // TODO: Include filename in error if missing
    let contents = fs::read_to_string(config.file_path)?;

    let results: Vec<&str> = contents.lines().collect();

    // TODO: Add solution runner harness
    // let results = if config.ignore_case {
    //     search_case_insensitive(&config.query, &contents)
    // } else {
    //     search(&config.query, &contents)
    // };

    // TODO: Remove once the runner harness is implemented
    for line in results {
        println!("{line}");
    }

    Ok(())
}
