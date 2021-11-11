# MathWars Persist Multiply

Unity Project of our game MathWars Persist Multiply based on CodeWars kata [Persist Bugger](https://www.codewars.com/kata/55bf01e5a717a0d57e0000ec)

A Multiply Educational and Competitive Game

# Scenes:

## Main Window
*Asks for your name at start.

- Logo at Top Screen
- MiddleScreen Buttons:
  - Single Player
  - Multiplayer
  - Exit Game
- Player name at bottom right of the screen

### Single Player Buttons:

- Rank [Rookie, Professional]
- Difficulty: [Easy, Medium, Hard, Impossible]
- Start Game

### Multiplayer Buttons:

 - Rank: [Rookie, Professional]
 - Difficulty: [Easy, Medium, Hard, Impossible]
 - Find Opponent

## In Game:

- Top of the screen:
  - Player name and Number of Lives (3 hearts?)
  - Timer to aswer questions
  - Score Points
- Middle of the screen:
  - Operation Details (numbers and math operators)
- Bottom of the screen:
  - Answer button options


# Logic of the game:

## Single Playar ROOKIE:

- A starter number will be randomly created, based on difficulty (example: 999).
- The multiply operators will appear between the digits of the number (example: 9*9*9)
-  The options of answer will be created randomly (example: B correct, A and C wrong)
- When a wrong answer is clicked, the player will lose a life and will not earn points, the next operation will be showing
- When the correct answer is clicked, the player will earn points with bonus from how faster he was and correct answers spree, the next operation will be based on the answer if it has more than one digit, if it has one digit, a new number will be shown and the player will have bonus extra time
- If the time is over or the player lost his last life, Game Over will be shown in middle of screen with the player name and his points / rank / difficulty level

## Single Player PROFESSIONAL:

- Almost the same as AMATEUR however the answer number to be clicked will not be the result of each digit operations, but the result number of the Multiplicative Persistence (the final number, not the multiply times called depth), some examples:
  - Starter Number: 39
  - Answer: 4 (because 3*9 = 27, 2*7 = 14, 1*4=4 and 4 has only one digit)

  - Starter Number: 999
  - Answer: 2 (Because 9*9*9 = 729, 7*2*9 = 126, 1*2*6=12, 1*2=2 and 2 has only one digit)

  - Starter Number: 11
  - Answer: 1 (Because 1*1 = 1 and 1 has only one digit)

- Poderá incluir abaixo do operador a profundidade das operações, como os exemplos:


    Número Original: 39
    Profundidade: 1/3 (pois iniciará na 1 e a resposta final passa por 3 multiplicações)

    Número Original: 999
    Resposta: 4 (pois iniciará na 1 e a resposta final passa por 4 multiplicações)

    Número Original: 11
    Resposta: 1/1 (pois iniciará na 1 e há apenas uma multiplicação)

Sobre as dificuldades, podem definir o tempo, profundidade das operações, quantidade de dígitos à serem multiplicados etc. No profissional no fácil pode até mesmo ir dando dicas abaixo da profundidade dando um "fade in" de todas as operações resolvidas da esquerda pra direita.

Multiplayer

 - Rank: Amateur / Profissional
 - Dificulty: Easy / Medium / Hard / Impossible
 - Botão BUSCAR OPONENTE

Assim como single player, porém irá aguardar outro jogador com os mesmos parâmetros também buscar um jogo.

Diferenças na tela entre single player e multiplayer:

- Vida e nome do jogador oponente lugar de pontos.
- Timer compartilhado
- Quando um jogador acerta uma resposta, piscará abaixo do nome dele em verde RESPOSTA CORRETA e ele aguardará o oponente responder a questão.
- Quando um jogador erra uma resposta, piscará abaixo do nome dele em vermelho RESPOSTA INCORRETA, ele perderá uma vida e aguardará o oponente responder a questão.
- Quando ambos responderem a questão, passará para a próxima também com acrescimo de tempo (que vai caindo a cada resposta dada).
- Quando o tempo acabar, os jogadores que não responderam a questão ainda irão perder uma vida e será calculado o número de vidas de ambos onde será mostrado no centro da tela bem grande, quem tiver mais será VOCÊ VENCEU, o oposto será VOCÊ PERDEU e caso ambos estiverem com a mesma quantidade de vida dará EMPATE.

- Após acabar o jogo ficará um timer de 30 segundos com dois botões perguntando:
    REVANCHE?
    VOLTAR AO MENU PRINCIPAL

Caso ambos apertarem REVANCHE até o timer acabar, uma nova partida entre os jogadores irá iniciar.
Se um dos jogadores apertar VOLTAR AO MENU PRINCIPAL, ambos serão levados ao menu principal.
