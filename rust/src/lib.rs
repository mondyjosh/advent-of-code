// use std::env;
use std::error::Error;
use std::fs;
use std::path::PathBuf;

use config::Config;

pub struct AocConfig {
    pub year: String,
    pub day: String,
    pub file_path: String,
}

impl AocConfig {
    pub fn build(mut args: impl Iterator<Item = String>) -> Result<AocConfig, &'static str> {
        // ignore arg[0] (binary name)
        args.next();

        // TODO: Check if Year and Day are integers
        let year = match args.next() {
            Some(arg) => arg,
            None => return Err("Didn't get a year"),
        };

        let day = match args.next() {
            Some(arg) => format!("{:02}", arg.parse::<i32>().unwrap()),
            None => return Err("Didn't get a day"),
        };

        let config = Config::builder()
            .add_source(config::File::from(PathBuf::from("./Settings")))
            .build()
            .unwrap();

        let template = &config.get::<String>("input_file_path_template").unwrap();
        let file_path = template.replace("{year}", &year).replace("{day}", &day);

        // TODO: Specify which year+day solution to use and set in Config

        Ok(AocConfig {
            year,
            day,
            file_path,
        })
    }
}

pub fn run(config: AocConfig) -> Result<(), Box<dyn Error>> {
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
