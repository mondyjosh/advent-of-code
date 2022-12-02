use std::env;
use std::process;

use aoc::AocConfig;

// use config::Config;
// use std::collections::HashMap;
// use std::fs;
// use std::path::PathBuf;

fn main() {
    // let settings = Config::builder()
    //     .add_source(config::File::from(PathBuf::from("./Settings")))
    //     .build()
    //     .unwrap();

    // let template = &settings.get::<String>("input_file_path_template").unwrap();
    // println!("{}", template);

    let config = AocConfig::build(env::args()).unwrap_or_else(|err| {
        eprintln!("Problem parsing arguments: {err}");
        process::exit(1);
    });

    if let Err(e) = aoc::run(config) {
        eprintln!("Application error: {e}");
        process::exit(1);
    }
}
